using CheckD.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckD.Domain.Command
{
    public interface IUpdateCheckListCommand
    {
        Task Execute(CheckListModel checkListModel);
    }
}
