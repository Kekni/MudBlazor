﻿using System.Text;

namespace MudBlazor.Docs.Compiler
{
    public class CodeBuilder
    {
        private readonly StringBuilder _code;
        private int _indentLevel;

        public CodeBuilder()
        {
            _code = new StringBuilder();
            _indentLevel = 0;
        }

        public string Code { get => _code.ToString(); }

        public int IndentLevel { get => _indentLevel; set => _indentLevel = value; }

        public void Add(string codeString)
        {
            Add(codeString, _indentLevel);
        }

        public void Add(string codeString, int indentLevel)
        {
            _code.Append(codeString.PadLeft(codeString.Length + (indentLevel * 4), ' '));
        }

        public void AddLine()
        {
            _code.Append("\n");
        }

        public void AddLine(string codeLine)
        {
            Add(codeLine);
            AddLine();
        }

        public void AddHeader()
        {
            AddLine("//-----------------------------------------------------------------------");
            AddLine("// This file is autogenerated by MudBlazor.Docs.Compiler");
            AddLine("// Any changes to this file will be overwritten on build");
            AddLine("// <auto-generated />");
            AddLine("//-----------------------------------------------------------------------");
            AddLine();
        }

        public void AddUsings()
        {
            AddLine("using System;");
            AddLine("using System.Net.Http;");

            AddLine("using Bunit;");
            AddLine("using Bunit.Rendering;");
            AddLine("using Bunit.TestDoubles;");

            AddLine("using Microsoft.AspNetCore.Components;");
            AddLine("using Microsoft.Extensions.DependencyInjection;");

            AddLine("using MudBlazor.Charts;");
            AddLine("using MudBlazor.Docs.Examples;");
            AddLine("using MudBlazor.Docs.Components;");
            AddLine("using MudBlazor.Docs.Wireframes;");
            AddLine("using MudBlazor.Internal;");
            AddLine("using MudBlazor.Services;");
            AddLine("using MudBlazor.UnitTests;");
            AddLine("using MudBlazor.UnitTests.Mocks;");

            AddLine("using Toolbelt.Blazor.HeadElement;");

            AddLine("using NUnit.Framework;");

            AddLine();
            AddLine("#if NET5_0");
            AddLine("using ComponentParameter = Bunit.ComponentParameter;");
            AddLine("#endif");
            AddLine();
        }

        public override string ToString()
        {
            return _code.ToString();
        }
    }
}
