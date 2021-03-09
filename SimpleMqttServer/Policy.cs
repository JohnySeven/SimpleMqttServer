using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Text.RegularExpressions;

namespace SimpleMqttServer
{
    public class Policy
    {
        public string Topic { get; set; }
        public bool AnyTopic { get; set; }
        public bool AllowSubscription { get; set; }
        public bool AllowPublish { get; set; }
        public bool UseRegex { get; set; } = false;
        

        private Regex _regexMatchInstance;

        public bool CheckTopic(string topicName)
        {
            if(!UseRegex)
            {
                return Topic == topicName;
            }
            else
            {
                if (_regexMatchInstance == null)
                {
                    _regexMatchInstance = new Regex(Topic, RegexOptions.Compiled);
                }

                return _regexMatchInstance.IsMatch(topicName);
            }
        }
    }
}
