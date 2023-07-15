// create a Custom attribute called LanguageFilterAttribute
//
// Path: src\Hub\LanguageFilterAttribute.cs
// using System;
//

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class LanguageFilterAttribute : Attribute
{
    public int FilterArgument { get; set; }
}

