using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace VaporStore.Data.Models
{
   public class GameTag
    {
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
        
        [ForeignKey(nameof(Tag))]
        public int  TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
