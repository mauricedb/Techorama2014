namespace System.Web.Mvc.Html
{
    public static class EditorExtensions
    {
        public static MvcHtmlString WebApiValidationSummary(this HtmlHelper html)
        {
            const string markup = @"
                <div class='alert alert-danger' ng-show='errors.length'>
                    <ul>
                        <li ng-repeat='error in errors'>{{error}}</li>
                    </ul>
                </div>";

            return MvcHtmlString.Create(markup);
        }

        public static MvcHtmlString FormUpdateButtons(this HtmlHelper html)
        {
            const string markup = @"
                <div class='form-group'>
                    <div class='col-sm-offset-2 col-sm-8'>
                        <button class='btn btn-primary' ng-click='save()' ng-disabled='form.$invalid'>Save</button>
                        <button class='btn btn-warning' ng-click='cancel()'>Cancel</button>
                    </div>
                </div>";

            return MvcHtmlString.Create(markup);
        }
    }
}