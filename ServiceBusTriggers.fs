namespace IsolatedFunctions.ServiceBusTriggers

open System
open Microsoft.Azure.Functions.Worker
open Microsoft.Azure.Functions.Worker.Http
open Microsoft.Extensions.Logging


type TestMessage = { Name: string; Departure: DateOnly }

type TestServiceBusTriggers() =

    [<Function("MultiOutputArray")>]
    [<ServiceBusOutput("testqueue", Connection = "ServiceBusConnection")>]
    member _.MultiSenderArray
        ([<HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "test-array")>] req: HttpRequestData)
        =
        Array.empty<TestMessage>

    [<Function("MultiOutputList")>]
    [<ServiceBusOutput("testqueue", Connection = "ServiceBusConnection")>]
    member _.MultiSenderList
        ([<HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "test-list")>] req: HttpRequestData)
        =
        List.empty<TestMessage>

    [<Function("MultiOutputSeq")>]
    [<ServiceBusOutput("testqueue", Connection = "ServiceBusConnection")>]
    member _.MultiSenderSeq
        ([<HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "test-seq")>] req: HttpRequestData)
        =
        Seq.empty<TestMessage>

    [<Function("SBReceiver")>]
    member _.Receiver
        ([<ServiceBusTrigger("testqueue", Connection = "ServiceBusConnection")>] msg: TestMessage)
        (ctx: FunctionContext)
        =
        let log: ILogger = ctx.GetLogger()
        log.LogInformation("Message received {msg}", msg)
