using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleCore.Interfaces
{
    public interface ICSharp
    {
        //特性:1.最外層要是public
        //note:是不是很像 function prototype 這邊是 class prototype
        //問題:是不是跟Blazor 的 component 很像
        string Title { get; set; } //設定屬性
        bool CSharpFunction(string input);
    }
}
