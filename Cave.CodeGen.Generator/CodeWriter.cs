using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cave.CodeGen.Generator;

sealed class CodeWriter
{
    readonly StringBuilder sb = new();
    readonly Stack<IdentMode> depth = new();
    int started = 0;

    public int Depth => depth.Count;

    public void Ident(IdentMode mode = IdentMode.Brackets, string? tag = null)
    {
        var code = mode switch { IdentMode.Brackets => "{", IdentMode.Tab => null, _ => throw new Exception() };
        if (code is not null) AddLine(code);
        depth.Push(mode);
    }

    public void UnIdent()
    {
        var mode = depth.Pop();
        var code = mode switch { IdentMode.Brackets => "}", IdentMode.Tab => null, _ => throw new Exception() };
        if (code is not null) AddLine(code);
    }

    public void StartLine(string? code = null)
    {
        if (++started != 1) throw new InvalidOperationException();
        Append(new string('\t', depth.Count));
        Append(code);
    }

    public void EndLine(string? code = null)
    {
        Append(code);
        if (--started != 0) throw new InvalidOperationException();
        sb.AppendLine();
    }

    public void Append(string? code = null)
    {
        if (started != 1) throw new InvalidOperationException();
        if (code is not null) sb.Append(code);
    }

    public void AddLine(string? code = null)
    {
        StartLine(code);
        EndLine();
    }

    public override string ToString()
    {
        if (started == 0 && depth.Count == 0)
        {
            return sb.ToString();
        }
        else
        {
            return $"// Code not completed: Ident {depth.Count} started {started} with {sb.ToString().Count(c => c == '\n')} lines.";
        }
    }
}
