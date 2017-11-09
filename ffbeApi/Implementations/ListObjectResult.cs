using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ffbeApi.Implementations
{
    public class ListObjectResult : ObjectResult
    {
        public string ListName { get; set; }
        public ListObjectResult(object value) : base(value)
        {
            ListName = "result";
            StatusCode = 200;
            Value = value;
        }

        public override void ExecuteResult(ActionContext context)
        {
            var vartable = new Dictionary<string, object>();
            vartable.Add("pageSize", 10);
            vartable.Add("page", 1);
            vartable.Add("count", 1000);
            vartable.Add(ListName, Value);
            Value = vartable;
            base.ExecuteResult(context);
        }

        public override Task ExecuteResultAsync(ActionContext context)
        {
            var vartable = new Dictionary<string, object>();
            vartable.Add("pageSize", 10);
            vartable.Add("page", 1);
            vartable.Add("count", 1000);
            vartable.Add(ListName, Value);
            Value = vartable;
            return base.ExecuteResultAsync(context);
        }
    }
}
