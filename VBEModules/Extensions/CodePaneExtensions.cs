﻿using System.Runtime.InteropServices;
using Microsoft.Vbe.Interop;


namespace VbeComponents.Extensions
{
    /// <summary>   VBE Code Pane extensions. </summary>
    [ComVisible(false)]
    public static class CodePaneExtensions
    {
        /// <summary>   A CodePane extension method that gets the current selection. </summary>
        /// <returns>   The selection. </returns>
        public static Selection GetSelection(this CodePane code)
        {
            int startLine;
            int endLine;
            int startColumn;
            int endColumn;

            code.GetSelection(out startLine, out startColumn, out endLine, out endColumn);
            return new Selection(startLine, startColumn, endLine, endColumn);
        }

        /// <summary>   A CodePane extension method that selected procedure. </summary>
        ///
        /// <param name="selection">    The selection. </param>
        /// <returns>   A Selection object representing the procedure the cursor is currently in. </returns>
        public static Selection SelectedProcedure(this CodePane code, Selection selection)
        {
            vbext_ProcKind kind;
            var procedure = code.CodeModule.get_ProcOfLine(selection.StartLine, out kind);
            var startLine = code.CodeModule.get_ProcStartLine(procedure, kind);
            var endLine = startLine + code.CodeModule.get_ProcCountLines(procedure, kind) + 1;

            return new Selection(startLine, 1, endLine, 1);
        }

        /// <summary>
        /// Sets the cursor to the first position of the given line.
        /// </summary>
        /// <param name="codePane"></param>
        /// <param name="lineNumber"></param>
        public static void SetSelection(this CodePane codePane, int lineNumber)
        {
            var line = codePane.CodeModule.Lines[lineNumber, 1];
            var selection = new Selection(lineNumber, 1, lineNumber, line.Length);
            codePane.SetSelection(selection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codePane"></param>
        /// <param name="selection"></param>
        public static void SetSelection(this CodePane codePane, Selection selection)
        {
            codePane.SetSelection(selection.StartLine, selection.StartColumn, selection.EndLine, selection.EndColumn + 1);            
        }
    }
}
