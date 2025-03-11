using System.Net;
using ARSoft.Tools.Net.Dns;

var dnsServer = new DnsServer(IPAddress.Any, 1, 1);
dnsServer.QueryReceived += async (sender, eventArgs) =>
{
    var query = eventArgs.Query as DnsMessage;
    var response = query.CreateResponseInstance();
    response.ReturnCode = ReturnCode.NoError;
    foreach (var question in query.Questions)
    {
        response.AnswerRecords.Add(new TxtRecord(question.Name, 30, "Hello from Magic Containers!"));
    }

    eventArgs.Response = response;
};
dnsServer.Start();

while (true)
{
    Thread.Sleep(100);
}