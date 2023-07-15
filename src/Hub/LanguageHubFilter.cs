using Microsoft.AspNetCore.SignalR;

public class LanguageHubFilter : IHubFilter
{
    // populated from a file or inline
    private List<string> bannedPhrases = new List<string> { "badword", "notcoolword" };

    public async ValueTask<object> InvokeMethodAsync(HubInvocationContext invocationContext, 
        Func<HubInvocationContext, ValueTask<object>> next)
    {
        var languageFilter = (LanguageFilterAttribute)Attribute.GetCustomAttribute(
            invocationContext.HubMethod, typeof(LanguageFilterAttribute));
        if (languageFilter != null &&
            invocationContext.HubMethodArguments.Count > languageFilter.FilterArgument &&
            invocationContext.HubMethodArguments[languageFilter.FilterArgument] is string str)
        {
            foreach (var bannedPhrase in bannedPhrases)
            {
                str = str.Replace(bannedPhrase, "***");
            }

            var arguments = invocationContext.HubMethodArguments.ToArray();
            arguments[languageFilter.FilterArgument] = str;
            invocationContext = new HubInvocationContext(invocationContext.Context,
                invocationContext.ServiceProvider,
                invocationContext.Hub,
                invocationContext.HubMethod,
                arguments);
        }

        return await next(invocationContext);
    }
}