using Logger.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Contracts
{
   public  interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }
       
        int MessageAppended { get; }

        void Append(IError error);




    }
}
