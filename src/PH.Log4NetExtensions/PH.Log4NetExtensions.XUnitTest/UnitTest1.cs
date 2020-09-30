using System;
using System.IO;
using System.Linq;
using log4net;
using Xunit;

namespace PH.Log4NetExtensions.XUnitTest
{
    public class UnitTest1
    {
        private ILog GetLogger()
        {
            //log4net.Config.XmlConfigurator.Configure();
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(@".\app.config"));
            var log = LogManager.GetLogger(typeof(UnitTest1));
            return log;
        }


        [Fact]
        public void TestTrace()
        {

            var log = GetLogger();


            

            log.Trace("a message", new Exception("some exception"));
            //var file = System.IO.File.ReadLines(@"./logs/testing.log");

            var contains = false;
            var txt      = "";
            using (FileStream stream = File.Open(@"./logs/testing.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    txt = reader.ReadToEnd();
                    
                }
            }

            var lines = txt.Split(new string[] {Environment.NewLine} , StringSplitOptions.RemoveEmptyEntries );
            contains = lines?.LastOrDefault(s => s.StartsWith($"{DateTime.Now.Year}", StringComparison.InvariantCultureIgnoreCase) )?.Contains(" TRACE ") ?? false;


            Assert.True(contains);
        }

        [Fact]
        public void TestScope()
        {
            var log = GetLogger();
            log.Debug("with no scope");
            using (LogScope.Init("testing my scope"))
            {
                log.Trace("a message with scope");
            }
            log.Debug("with no scope2");

            var contains = false;
            var txt      = "";
            using (FileStream stream = File.Open(@"./logs/testing.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    txt = reader.ReadToEnd();
                    
                }
            }


            var lines  = txt.Split(new string[] {Environment.NewLine} , StringSplitOptions.RemoveEmptyEntries );
            var scoped = lines[lines.Length - 2];
            contains = scoped?.Contains("[NDC:testing my scope]") ?? false;
            var noContains = lines.LastOrDefault()?.Contains("[NDC:(null)]") ?? false;

            Assert.True(contains);
            Assert.True(noContains);
        }

        [Fact]
        public void TestTraceScope()
        {
            


            var log = GetLogger();
            log.Debug("with no scope");
            using (log.InitTraceLogScope("TRScope"))
            {
                log.Trace("a message with scope");
            }
            log.Debug("with no scope2");

            var contains = false;
            var txt      = "";
            using (FileStream stream = File.Open(@"./logs/testing.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    txt = reader.ReadToEnd();
                    
                }
            }


            var lines  = txt.Split(new string[] {Environment.NewLine} , StringSplitOptions.RemoveEmptyEntries );
            var scoped = lines[lines.Length - 2];
            contains = scoped?.Contains("[NDC:TRScope]") ?? false;
            var noContains = lines.LastOrDefault()?.Contains("[NDC:(null)]") ?? false;

            Assert.True(contains);
            Assert.True(noContains);
        }
    }
}
