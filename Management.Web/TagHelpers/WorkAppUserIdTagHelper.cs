using Management.Business.Abstract;
using Management.Entities.Concrete;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.Web.TagHelpers
{
    [HtmlTargetElement("getAppUserId")]
    public class WorkAppUserIdTagHelper : TagHelper
    {
        private readonly IWorkService _workService;

        public WorkAppUserIdTagHelper(IWorkService workService)
        {
            _workService = workService;
        }

        public int appUserId { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            List<Work> works = _workService.GetWithAppUserId(appUserId);

            var completedWorks = works.Where(x => x.Status).Count();
            var unCompletedWorks = works.Where(x => !x.Status).Count();

            string html = $" Tamamladığı görev sayısı : {completedWorks} <br> " +
                $"Şuan çalıştığı görev sayısı : {unCompletedWorks}";

            output.Content.SetHtmlContent(html);

        }

    }
}
