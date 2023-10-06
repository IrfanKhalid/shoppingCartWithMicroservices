// See https://aka.ms/new-console-template for more information
using Akka.Actor;
using Akka.Event;
using Akka.Util;
using Akka.Util.Extensions;
using System.Net.NetworkInformation;

Console.WriteLine("Hello, World!");

var actorSystem = ActorSystem.Create("Ping Pong");

var pingActorProps = Props.Create(factory: () => new PingActor());

IActorRef pingActor=actorSystem.ActorOf(pingActorProps,name:"ping");

pingActor.Tell(new Ping());


public class PingActor : Akka.Actor.ReceiveActor
{
    private readonly ILoggingAdapter _log = Context.GetLogger();

	public PingActor()
	{
		Receive<Ping>(handler: p =>
		{

			_log.Info(format: "Received {0}", p);

			var replytime = TimeSpan.FromSeconds(
				ThreadLocalRandom.Current.Next(1, 5));

			Context.System.Scheduler.ScheduleTellOnce(
				replytime,
				Sender,
				message: p.ToString(),
				Self
				);
		});

	}



}