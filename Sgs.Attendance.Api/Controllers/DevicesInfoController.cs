using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Sgs.Attendance.Api.Models;
using Sgs.Attendance.BusinessLogic;
using Sgs.Attendance.Model;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;

namespace Sgs.Attendance.Api.Controllers
{
    public class DevicesInfoController : GeneralApiController<DeviceInfo, DeviceInfoModel>
    {
        public DevicesInfoController(DevicesInfoManager dataManager,
            IMapper mapper, ILogger<DevicesInfoController> logger) : base(dataManager, mapper, logger)
        {
        }

        private async Task<bool> deviceConnected(string ipAddress)
        {
            var pingSender = new Ping();
            PingReply reply = await pingSender.SendPingAsync(ipAddress);
            return reply.Status == IPStatus.Success;
        }

        protected override async Task<List<DeviceInfoModel>> fillItemsListMissingData(List<DeviceInfoModel> resultData)
        {
            foreach (var device in resultData)
            {
                device.Connected = await deviceConnected(device.IpAddress);
            }
            return resultData;
        }

        [HttpGet("pingByIp/{ipAddress}")]
        public async Task<bool> sendPingByIp(string ipAddress)
        {
            var pingSender = new Ping();
            PingReply reply = await pingSender.SendPingAsync(ipAddress);
            return reply.Status == IPStatus.Success;
        }
    }
}
