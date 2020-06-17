﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data
{
    public class Message
    {
        public int ID { get; set; }

        public int SenderID { get; set; }

        public int ReceiverID { get; set; }

        public string Content { get; set; }

        public DateTime SendTime { get; set; }
    }
}
