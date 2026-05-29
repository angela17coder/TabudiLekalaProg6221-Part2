//Implement user name memory functionality
using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class CybersecurityBot
    {
        private readonly Random random = new Random();

        private readonly UserMemory memory = new UserMemory();

        private string lastTopic = "";

        private readonly Dictionary<string, List<string>> responses =
            new Dictionary<string, List<string>>()
        {
            {
                "password",
                new List<string>()
                {
                    "Use strong passwords with symbols and numbers.",
                    "Never use your birthday as a password.",
                    "Use different passwords for every account."
                }
            },

            {
                "phishing",
                new List<string>()
                {
                    "Never click suspicious email links.",
                    "Check the sender email carefully.",
                    "Phishing emails often create urgency."
                }
            },

            {
                "privacy",
                new List<string>()
                {
                    "Review your privacy settings regularly.",
                    "Avoid sharing personal information online.",
                    "Use VPNs on public Wi-Fi."
                }
            },

            {
                "malware",
                new List<string>()
                {
                    "Keep your antivirus updated.",
                    "Do not download cracked software.",
                    "Malware can steal your data silently."
                }
            },

            {
                "scam",
                new List<string>()
                {
                    "Never send OTPs to strangers.",
                    "Scammers pretend to be trusted companies.",
                    "If it sounds too good to be true, it probably is."
                }
            }
        };

        public string GetResponse(string input)
        {
            string lower = input.ToLower();

            // NAME MEMORY
            if (lower.Contains("my name is"))
            {
                string name = input.Substring(input.ToLower().IndexOf("my name is") + 10).Trim();

                memory.UserName = name;

                return $"Nice to meet you {name}! I will remember your name.";
            }

            // GREETING
            if (lower == "hi" || lower == "hello" || lower.Contains("hey"))
            {
                if (!string.IsNullOrEmpty(memory.UserName))
                {
                    return $"Hello {memory.UserName}! How can I help you with cybersecurity today?";
                }

                return "Hello! Tell me your name by saying 'My name is Lesedi'";
            }

            // SENTIMENT DETECTION
            if (lower.Contains("worried"))
            {
                return "It is understandable to feel worried about cybersecurity. Let me help you stay safe online.";
            }

            if (lower.Contains("frustrated"))
            {
                return "Cybersecurity can feel confusing at first, but I can explain it more simply.";
            }

            if (lower.Contains("curious"))
            {
                return "Curiosity is great in cybersecurity because learning keeps you safe online.";
            }

            // FOLLOW UP
            if (lower.Contains("tell me more") || lower.Contains("another tip"))
            {
                if (lastTopic != "")
                {
                    return GetRandomResponse(lastTopic);
                }

                return "Please tell me which cybersecurity topic you want more information about.";
            }

            // HELP
            if (lower.Contains("help"))
            {
                return "I can help with passwords, phishing, scams, malware, privacy and VPN safety.";
            }

            // KEYWORD RECOGNITION
            foreach (var keyword in responses.Keys)
            {
                if (lower.Contains(keyword))
                {
                    lastTopic = keyword;

                    return GetRandomResponse(keyword);
                }
            }

            // DEFAULT RESPONSE
            return "I'm not sure I understand. Can you try rephrasing?";
        }

        private string GetRandomResponse(string keyword)
        {
            List<string> tips = responses[keyword];

            int index = random.Next(tips.Count);

            return tips[index];
        }

        public string GetUserName()
        {
            return memory.UserName;
        }
    }
}
