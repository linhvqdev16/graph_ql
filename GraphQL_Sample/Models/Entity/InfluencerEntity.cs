using System;
namespace GraphQL_Sample.Models.Entity
{
	public class InfluencerEntity
	{
		public int? Id { get; set; }
		public int? ScoinId { get; set;  }
		public string? ScoinName { get; set; }
		public float? Point { get; set; }
		public int? GameId { get; set;  }
		public int? ServerId { get; set; }
		public int? RoleId { get; set;  }
		public string? RoleName { get; set; }
		public string? NickName { get; set; }
		public string? Sologan { get; set; }
		public string? ReferenceName { get; set; }
		public string? YoutubeChanel { get; set; }
		public string? LiveGChanel { get; set; }
		public string? TwitchChanel { get; set; }
		public DateTime? CreateDate { get; set; }
		public DateTime? LastUpdate { get; set;  }
		public int? Status { get; set; }
	}
}

