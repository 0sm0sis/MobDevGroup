using System;
using System.Collections.Generic;
using System.Text;
using TerminalCharacter.Models;

namespace TerminalCharacter.ViewModels
{
    public class MonstersDetailViewModel : BaseViewModel
    {
        public Monster Data { get; set; }
        public MonstersDetailViewModel(Monster data = null)
        {
            Title = data?.Name;
            Data = data;
        }
    }
}
