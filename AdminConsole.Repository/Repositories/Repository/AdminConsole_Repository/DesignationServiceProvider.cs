using CodeGen.Repository.Repositories.Interfaces;
using System.Data;
using Dapper;
using AdminConsole.Repository.BaseRepository;
using AdminConsole.Repository.Factory;
using CodeGen.Model.DesignationMasterModel;
using CodeGen.Model.SuccessMessage;
namespace CodeGen.Repository.Repository
{
    public class DesignationServiceProvider: CachDB10RepositoryBase,IDesignationServiceProvider
    {
      
        public DesignationServiceProvider(ICachDB10ConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
            public string AddDesignation(DesignationMaster model)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_NVCHDESIGNAME", model.NVCHDESIGNAME);
                p.Add("@P_NVCHALIASNAME", model.NVCHALIASNAME);
                p.Add("@P_INTCREATEDBY", model.INTCREATEDBY);
                p.Add("@P_INTUPDATEDBY", model.INTCREATEDBY);
                p.Add("@P_ACTION", "A");
                p.Add("@P_Msg", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                var query = "USP_MASTER_DESIGNATION_MANAGE";
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
        public async Task<DesignationMasterModel> GetAllDesgination(int id)

        {
            try
            {

                var dyParam = new DynamicParameters();
                dyParam.Add("@P_Action", "VD");
                dyParam.Add("@P_BITSTATUS",  id);
                dyParam.Add("@cur", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585); 
                var query = "USP_DESIGNATION_MANAGE_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<DesignationMaster>();
                DesignationMasterModel viewModel = new DesignationMasterModel();
                viewModel.DesignationMasterList = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public string MarkActive(DesignationMaster model)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;

            try
            {
                var dyParam = new DynamicParameters();
                dyParam.Add("@P_Action","ACTIVE");
                dyParam.Add("@P_INTUPDATEDBY", model.INTUPDATEDBY);
                dyParam.Add("@P_INTDESIGID", model.INTDESIGID);
                dyParam.Add("@P_Msg", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                var query = "USP_MASTER_DESIGNATION_MANAGE";
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
        public string MarkInactive(DesignationMaster model)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new DynamicParameters();
                dyParam.Add("@P_Action", "I");
                dyParam.Add("@P_INTUPDATEDBY", model.INTUPDATEDBY);
                dyParam.Add("@P_INTDESIGID", model.INTDESIGID);
               // var query = "USP_MASTER_DESIGNATION_MANAGE";
                dyParam.Add("@P_Msg", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                var query = "USP_MASTER_DESIGNATION_MANAGE";
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
        public async Task<DesignationMasterModel> GetById(int id)

        {
            try
            {
                var dyParam = new DynamicParameters();
                dyParam.Add("@P_Action",  "E");
                dyParam.Add("@P_INTDESIGID", id);
                dyParam.Add("@cur", DbType.String, direction:ParameterDirection.Output,size:5215585);
                var query = "USP_DESIGNATION_MANAGE_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<DesignationMaster>();
                DesignationMasterModel viewModel = new DesignationMasterModel();
                viewModel.DesignationMasterList = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
           
                throw ex;
            }
        }
        public string EditDesignation(DesignationMaster model)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new DynamicParameters();
                dyParam.Add("@P_ACTION","U");
                dyParam.Add("@P_INTDESIGID",model.INTDESIGID);
                dyParam.Add("@P_NVCHDESIGNAME",model.NVCHDESIGNAME);
                dyParam.Add("@P_NVCHALIASNAME",model.NVCHALIASNAME);
                dyParam.Add("@P_INTUPDATEDBY", model.INTUPDATEDBY);
                dyParam.Add("@P_Msg", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                var query = "USP_MASTER_DESIGNATION_MANAGE";
                SuccessMessages = Connection.Query<SuccessMessage>(query, dyParam, commandType: CommandType.StoredProcedure);
                strOutput = SuccessMessages.AsList()[0].successmessage.ToString();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return strOutput;

        }
               
    }
}
