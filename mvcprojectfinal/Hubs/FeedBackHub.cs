using Microsoft.AspNetCore.SignalR;
using mvcprojectfinal.Models;

namespace mvcprojectfinal.Hubs
{
	public class FeedBackHub :Hub
	{
		Context Context = new Context();
		public void NewMessage(string name, string comment, int HotID)
		{
			//save db BLogic
			//notify  Another Online Client
			Clients.All.SendAsync("NewMessageNotify",name,comment, HotID);//nameof Client method,data 
			Context.feedBacks.Add(new FeedBack {name=name,comment = comment, HotelsID = HotID });

			Context.SaveChanges();
		}

	}
}
