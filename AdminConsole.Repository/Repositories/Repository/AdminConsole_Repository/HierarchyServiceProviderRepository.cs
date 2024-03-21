using CodeGen.Repository.Repositories.Interfaces;
using CodeGen.Model.HirerachyMaster;
using System.Data;
using Dapper;
using AdminConsole.Repository.BaseRepository;
using AdminConsole.Repository.Factory;
using System.Linq;
using CodeGen.Model.SuccessMessage;

namespace CodeGen.Repository.Repository
{
    public class HierarchyServiceProviderRepository : CachDB10RepositoryBase, IHierarchyServiceProviderRepository
    {

        public HierarchyServiceProviderRepository(ICachDB10ConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public string AddHierarchy(Hierarchy objhierarchy)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_NVCHHIERARCHYNAME", objhierarchy.NVCHHIERARCHYNAME);
                p.Add("@P_VCHHIERARCHYALIAS", objhierarchy.VCHHIERARCHYALIAS);
                p.Add("@P_INTNOLEVEL", objhierarchy.INTNOLEVEL);
                p.Add("@P_NVCHADDRESS", objhierarchy.NVCHADDRESS);
                p.Add("@P_INTCREATEDBY", objhierarchy.INTCREATEDBY);
                p.Add("@P_ACTION", "A");
                p.Add("@P_Msg", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                var query = "USP_HierarchyMaster_MANAGE";
                SuccessMessages = Connection.Query<SuccessMessage>(query, p, commandType: CommandType.StoredProcedure);
                strOutput = SuccessMessages.AsList()[0].successmessage.ToString();
            }
            catch (Exception ex)
            {
                // Logger.LogError(ex, ex.Message, Model);
                throw ex;
            }
            return strOutput;

        }

        public string EditHierarchy(Hierarchy objhierarchy)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {

                var p = new DynamicParameters();
                p.Add("@P_INTHIERARCHYID", objhierarchy.INTHIERARCHYID);
                p.Add("@P_NVCHHIERARCHYNAME", objhierarchy.NVCHHIERARCHYNAME);
                p.Add("@P_VCHHIERARCHYALIAS", objhierarchy.VCHHIERARCHYALIAS);
                p.Add("@P_INTNOLEVEL", objhierarchy.INTNOLEVEL);
                p.Add("@P_NVCHADDRESS", objhierarchy.NVCHADDRESS);
                p.Add("@P_INTCREATEDBY", objhierarchy.INTCREATEDBY);
                p.Add("@P_ACTION", "E");
                p.Add("@P_Msg", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                var query = "USP_HierarchyMaster_MANAGE";
                SuccessMessages = Connection.Query<SuccessMessage>(query, p, commandType: CommandType.StoredProcedure);
                strOutput = SuccessMessages.AsList()[0].successmessage.ToString();
            }
            catch (Exception ex)
            {
                // Logger.LogError(ex, ex.Message, Model);
                throw ex;
            }
            return strOutput;
        }

        public async Task<HierarchyModel> GetAllHierarchy(int id)
        {
            try
            {

                var p = new DynamicParameters();
                p.Add("@P_intStatus", id);

                p.Add("@P_Action", "V");
                p.Add("@cur", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                var result = await Connection.QueryMultipleAsync("USP_HierarchyMaster_VIEW", p, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<Hierarchy>();
                HierarchyModel viewModel = new HierarchyModel();
                viewModel.HierarchyList = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }

        public async Task<HierarchyModel> GetById(int id)
        {
            try
            {
                var dyParam = new DynamicParameters();

                dyParam.Add("@P_INTHIERARCHYID", id);
                dyParam.Add("@P_Action", "VI");
                dyParam.Add("@cur", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                var query = "USP_HierarchyMaster_VIEW";

                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<Hierarchy>();
                HierarchyModel viewModel = new HierarchyModel();
                viewModel.HierarchyList = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public string MarkActive(Hierarchy objhierarchy)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;

            try
            {
                var dyParam = new DynamicParameters();

                dyParam.Add("@P_INTHIERARCHYID", objhierarchy.INTHIERARCHYID);
                dyParam.Add("@P_ACTION", "EA");
                dyParam.Add("@P_Msg", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                var query = "USP_HierarchyMaster_MANAGE";
                SuccessMessages = Connection.Query<SuccessMessage>(query, dyParam, commandType: CommandType.StoredProcedure);
                strOutput = SuccessMessages.AsList()[0].successmessage.ToString();
            }
            catch (Exception ex)
            {
                // Logger.LogError(ex, ex.Message, Model);
                throw ex;
            }
            return strOutput;

        }

        public string MarkInactive(Hierarchy objhierarchy)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;

            try
            {

                var dyParam = new DynamicParameters(); ;
                dyParam.Add("@P_INTHIERARCHYID", objhierarchy.INTHIERARCHYID);
                dyParam.Add("@P_ACTION", "I");
                dyParam.Add("@P_Msg", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                var query = "USP_HierarchyMaster_MANAGE";
                SuccessMessages = Connection.Query<SuccessMessage>(query, dyParam, commandType: CommandType.StoredProcedure);
                strOutput = SuccessMessages.AsList()[0].successmessage.ToString();
            }
            catch (Exception ex)
            {
                // Logger.LogError(ex, ex.Message, Model);
                throw ex;
            }
            return strOutput;
        }

    }
}
