using Four.WebApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Four.WebApi.Controllers
{
    [BasicAuthorize]
    public class BaseController : ApiController
    {
    }
}
