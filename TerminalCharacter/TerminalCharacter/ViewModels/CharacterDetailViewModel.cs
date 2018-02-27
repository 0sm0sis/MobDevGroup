using System;
using System.Collections.Generic;
using System.Text;
using TerminalCharacter.Models;

namespace TerminalCharacter.ViewModels
{
    public class CharacterDetailViewModel : BaseViewModel
    {
        public Player Data { get; set; }
        public CharacterDetailViewModel(Player data = null)
        {
            Title = data?.Name;
            Data = data;
        }
    }

}
