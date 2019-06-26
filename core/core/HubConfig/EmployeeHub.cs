using Microsoft.AspNetCore.SignalR;
using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.HubConfig
{
    public class EmployeeHub : Hub
    {
        public async Task Broadcastemployeedata(List<Employee> data) => await Clients.All.SendAsync("broadcastemployeedata", data);
    }
}