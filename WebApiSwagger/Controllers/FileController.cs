using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiSwagger.Attr;

namespace WebApiSwagger.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpPost]
        public async Task<string> Post([FromFile]UserFile file)
        {
            if (file == null || !file.IsValid)
                return "请选择合适的文件";

            string newFile = string.Empty;
            if (file != null)
                newFile = await file.SaveAs("/data/files/images");

            return  "处理成功";
            //return new JsonResult(new { code = 0, message = "成功", url = newFile });
        }

    }
}