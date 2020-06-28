using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.WebUI.Helpers.TagHelpers //Burdaki öğeleri kullanabilmek için ViewImports altına src vermemiz gerekir.
{
    [HtmlTargetElement("KemsParagraph")] // <KemsParagraph> İÇERİK </KemsParagraph> olarak çalışmasını sağlar
    public class Paragraph : TagHelper
    {

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //string data,tagbuilder ve stringbuilder ile çalışabiliriz.

            var tagbuilder = new TagBuilder("p");
            tagbuilder.InnerHtml.AppendHtml("<b>KemsTroisi</b>");
            output.Content.SetHtmlContent(tagbuilder);

            base.Process(context, output);


        }

    }
}
