using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialog
{
    class Calculator : Dialog
    {
        String numberGram;
        public Calculator()
        {
            numberGram = System.IO.File.ReadAllText("number.txt");
        }
        public override string ToString()
        {
            return "calculator";
        }

        public override void Run(Action<string> print)
        {
            while (true)
            {
                activeSession = new SarmataSession(host, new Dictionary<string, string>{
                        { "grammar", numberGram },
                        { "complete-timeout", "1000" },
                        { "incomplete-timeout", "3000" },
                        { "no-input-timeout", "7000" },
                        { "no-rec-timeout", "10000" },
                    });
                //TODO: add calculator logic

                var response = activeSession.WaitForResponse();
                print(status2string(response));
                response = activeSession.WaitForResponse();
                print(status2string(response));
            }
        }
    }
}
