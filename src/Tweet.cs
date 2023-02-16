﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeScreen.Assessments.TweetsApi.src
{
    public class Tweet
    {
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Text { get; set; }

        public User User { get; set; }
    }
}
