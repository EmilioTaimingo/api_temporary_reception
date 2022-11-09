using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using api_temporary_reception.Models;
using api_temporary_reception.Context;

namespace api_temporary_reception.Controllers
{
    public class TemporaryReceptionController : ApiController
    {
        public Reply Post([FromBody] Reception oReception)
        {
            Reply oReply = new Reply();
            if(oReception.Guide_Number=="")
            {
                oReply.Message = "Empty Guide Number";
                oReply.Result = 401;
                return oReply;
            }
            if (oReception.Operator_Id.ToString() == "")
            {
                oReply.Message = "Empty Operator_Id";
                oReply.Result = 402;
                return oReply;
            }
            if (oReception.Status_Id.ToString() == "")
            {
                oReply.Message = "Empty Status_Id";
                oReply.Result = 403;
                return oReply;
            }
            if (oReception.Condition_Id.ToString() == "")
            {
                oReply.Message = "Empty Condition_Id";
                oReply.Result = 404;
                return oReply;
            }
            if (oReception.Photography == "")
            {
                oReply.Message = "Empty Photography";
                oReply.Result = 405;
                return oReply;
            }


            temporary_ReceptionCommands temporary_ReceptionCommands = new temporary_ReceptionCommands();
            oReply = temporary_ReceptionCommands.Recepcion_Temporal(oReception);
            return oReply;

        }
    }
}
