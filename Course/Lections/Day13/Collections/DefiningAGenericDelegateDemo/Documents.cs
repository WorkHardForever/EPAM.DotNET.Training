using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningAGenericTypeDemo
{
    class Report : IPrintable
    {
        string title;

        public Report(string Title)
        {
            this.title = Title;
        }

        public string Title
        {
            get { return title; }
        }

        public string Print()
        {
            // Add a pause to ensure that the time changes between documents (important for random number generation).
            System.Threading.Thread.Sleep(2000);           

            Random rand = new Random();
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("REPORT: {0}", this.Title);
            builder.AppendLine();
            if (rand.Next(10) > 5)
            {
                builder.AppendFormat("Status: OK");
            }
            else
            {
                builder.AppendFormat("Status: OK");
            }
            builder.AppendLine();
            if (rand.Next(10) > 5)
            {
                builder.AppendFormat("Project: On Schedule");
            }
            else
            {
                builder.AppendFormat("Project: Behind Schedule");
            }
            builder.AppendLine();
            if (rand.Next(10) > 5)
            {
                builder.AppendFormat("Budget: On Target");
            }
            else
            {
                if (rand.Next(10) > 5)
                {
                    builder.AppendFormat("Budget: Below Target");
                }
                else
                {
                    builder.AppendFormat("Budget: Above Target");
                }
            }
            builder.AppendLine();
            builder.Append("END REPORT");
            return builder.ToString();
        }
    }

    class ReferenceGuide : IPrintable
    {
        string title;

        public ReferenceGuide(string Title)
        {
            this.title = Title;
        }

        public string Title
        {
            get { return title; }
        }

        public string Print()
        {
            // Add a pause to ensure that the time changes between documents (important for random number generation).
            System.Threading.Thread.Sleep(2000);

            Random rand = new Random();
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("Reference Guide: {0}", this.Title);
            builder.AppendLine();
            if (rand.Next(10) > 5)
            {
                builder.AppendFormat("Checklist:");
            }
            else
            {
                builder.AppendFormat("Items for verification:");
            }
            builder.AppendLine();
            if (rand.Next(10) > 5)
            {
                builder.AppendFormat("Power light on");
            }
            else
            {
                builder.AppendFormat("Monitor power on");
            }
            builder.AppendLine();
            if (rand.Next(10) > 5)
            {
                builder.AppendFormat("Fans spinning");
            }
            else
            {
                if (rand.Next(10) > 5)
                {
                    builder.AppendFormat("All connections correct");
                }
                else
                {
                    builder.AppendFormat("Drives spinning");
                }
            }
            builder.AppendLine();
            builder.Append("End of Reference Guide");
            return builder.ToString();
        }
    }
}
