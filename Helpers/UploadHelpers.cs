using System.Collections.Generic;
using System.Web.Mvc;
using JetBrains.Annotations;

namespace AspNetUploadHelpers.Infrastructure.Helpers
{
    public static class UploadHelpers
    {
        //TODO: Test integration with TaskManager
        public static MvcHtmlString UploadImage(this HtmlHelper html,[AspMvcAction]string actionName,[AspMvcController]string controllerName)
        {
            var formTag = new TagBuilder("form");
            
            var attributesCollection = new Dictionary<string, string>
            {
                {"action", controllerName + "/" + actionName},
                {"method", "post"},
                {"enctype", "multipart/form-data"}
            };
            formTag.MergeAttributes(attributesCollection);
            var divInputGroupTag = new TagBuilder("div");
            divInputGroupTag.MergeAttribute("class", "input-group");
            var spanInputGroupBtnTag = new TagBuilder("span");
            spanInputGroupBtnTag.MergeAttribute("class", "input-group-btn");
            var labelBtnFileTag = new TagBuilder("label");
            labelBtnFileTag.MergeAttribute("class", "btn btn-primary btn-file");
            var inputTagBuilder = new TagBuilder("input");
            
            var attributesCollectionForInput = new Dictionary<string, string>
            {
                {"type", "file"},
                {"id", "file"},
                //pass as parametr
                {"name", "file"},
                {"style", "display: none;"},
                {"onchange", "uploadImageHelper.fileSelection()"}
            };
            inputTagBuilder.MergeAttributes(attributesCollectionForInput);
            labelBtnFileTag.InnerHtml = " Browse";
            labelBtnFileTag.InnerHtml += inputTagBuilder.ToString();
            labelBtnFileTag.ToString(TagRenderMode.EndTag);
            
            var inputBtnDefaultTag = new TagBuilder("input");
            
            var attributesCollectionForSpanInput = new Dictionary<string, string>()
            {
                {"type", "submit"},
                {"class", "btn btn-default"},
                {"value", "Upload"}
            };
            inputBtnDefaultTag.MergeAttributes(attributesCollectionForSpanInput);
            inputBtnDefaultTag.ToString(TagRenderMode.EndTag);
            spanInputGroupBtnTag.InnerHtml += labelBtnFileTag.ToString();
            spanInputGroupBtnTag.InnerHtml += inputBtnDefaultTag.ToString();
            spanInputGroupBtnTag.ToString(TagRenderMode.EndTag);

            var input3TagBuilder = new TagBuilder("input");
          
            var attributesCollectionForInputFile = new Dictionary<string, string>
            {
                {"type", "text"},
                {"id", "filefield"},
                {"class", "form-control"}
            };
            input3TagBuilder.MergeAttributes(attributesCollectionForInputFile);
            
            divInputGroupTag.InnerHtml += spanInputGroupBtnTag.ToString();
            divInputGroupTag.InnerHtml += input3TagBuilder.ToString();
            divInputGroupTag.ToString(TagRenderMode.EndTag);
            formTag.InnerHtml += divInputGroupTag.ToString();
            return new MvcHtmlString(formTag.ToString());
        }

        public static MvcHtmlString UploadImageWithThumbnail(this HtmlHelper html,[AspMvcAction]string actionName,[AspMvcController]string controllerName)
        {
            var formTag = new TagBuilder("form");
            var attributesCollection = new Dictionary<string, string>
            {
                {"action", controllerName + "/" + actionName},
                {"method", "post"},
                {"enctype", "multipart/form-data"}
            };
            formTag.MergeAttributes(attributesCollection);

            var divThumbnailTag = new TagBuilder("div");
            var attributesDivCollection = new Dictionary<string, string>
            {
                {"class", "thumbnail"},
                {"id", "photocard"},
            };
            divThumbnailTag.MergeAttributes(attributesDivCollection);
            var imageTag = new TagBuilder("img");
            imageTag.MergeAttribute("src", "http://placehold.it/242x200");
            imageTag.ToString(TagRenderMode.EndTag);
            divThumbnailTag.InnerHtml += imageTag.ToString();
            divThumbnailTag.ToString(TagRenderMode.EndTag);
            formTag.InnerHtml += divThumbnailTag.ToString();
            formTag.InnerHtml += GenerateInputGroupDiv("uploadImageHelper.uploadFile(this.files)","file");
            return new MvcHtmlString(formTag.ToString());
            
        }

        public static MvcHtmlString UploadImagesWithThumbnail(this HtmlHelper html,[AspMvcAction]string actionName,[AspMvcController]string controllerName)
        {
            var formTag = new TagBuilder("form");
            var attributesCollection = new Dictionary<string, string>
            {
                {"action", controllerName + "/" + actionName},
                {"method", "post"},
                {"enctype", "multipart/form-data"}
            };
            formTag.MergeAttributes(attributesCollection);
            var divCardPlecaHoldertag = new TagBuilder("div");
            var attributesDivCollection = new Dictionary<string, string>
            {
                {"class", "cardPlaceHolder"},
                {"id", "cardPlaceHolder"},
            };
            divCardPlecaHoldertag.MergeAttributes(attributesDivCollection);
            divCardPlecaHoldertag.ToString(TagRenderMode.EndTag);
            formTag.InnerHtml += divCardPlecaHoldertag.ToString();
            formTag.InnerHtml += GenerateInputGroupDiv("uploadImageHelper.uploadFiles(this.files)","files");
            return new MvcHtmlString(formTag.ToString());
            
        }

        private static MvcHtmlString GenerateInputGroupDiv(params string[] configurationParams)
        {
            var divTag = new TagBuilder("div");
            divTag.MergeAttribute("class", "input-group");
            var spanInputGroupBtnTag = new TagBuilder("span");
            spanInputGroupBtnTag.MergeAttribute("class", "input-group-btn");
            var labelBtnPrimaryFileTagBuilder = new TagBuilder("label");
            labelBtnPrimaryFileTagBuilder.MergeAttribute("class", "btn btn-primary btn-file");
            var iconSpan = new TagBuilder("span");
            iconSpan.MergeAttribute("class", "glyphicon glyphicon-folder-open");
            iconSpan.ToString(TagRenderMode.EndTag);
            labelBtnPrimaryFileTagBuilder.InnerHtml += iconSpan.ToString();
            labelBtnPrimaryFileTagBuilder.InnerHtml = "Browse";
            var inputTag = new TagBuilder("input");
            inputTag.MergeAttribute("type", "file");
            inputTag.MergeAttribute("id", "file");
            inputTag.MergeAttribute("name", configurationParams[1]);
            inputTag.MergeAttribute("style", "display: none;");
            inputTag.MergeAttribute("multiple accept", "image/*");
            inputTag.MergeAttribute("onchange", configurationParams[0]);
            labelBtnPrimaryFileTagBuilder.InnerHtml += inputTag.ToString();
            labelBtnPrimaryFileTagBuilder.ToString(TagRenderMode.EndTag);
            var inputBtnDefaultTagBuilder = new TagBuilder("input");
            inputBtnDefaultTagBuilder.MergeAttribute("type", "submit");
            inputBtnDefaultTagBuilder.MergeAttribute("class", "btn btn-default");
            inputBtnDefaultTagBuilder.MergeAttribute("value", "Upload");
            spanInputGroupBtnTag.InnerHtml += labelBtnPrimaryFileTagBuilder.ToString();
            spanInputGroupBtnTag.InnerHtml += inputBtnDefaultTagBuilder.ToString();
            spanInputGroupBtnTag.ToString(TagRenderMode.EndTag);
            divTag.InnerHtml += spanInputGroupBtnTag.ToString();
            divTag.ToString(TagRenderMode.EndTag);
            
            return new MvcHtmlString(divTag.ToString());
        }
    }
}
