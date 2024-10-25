namespace lyqbing.DGLAB
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using UnityEngine;

	public static class DGLab
	{
		/// <summary>
		/// 获取游戏响应数据
		/// </summary>S
		public static async Task<GameResponse> GetGameResponse()
		{
			string JsonPost = await FTPManager.Get(CoyoteApi.Instance.GameResponseApi);
			DeLog(JsonPost);
			return JsonUtility.FromJson<GameResponse>(JsonPost);
		}

		/// <summary>
		/// 【将会过时】获取脉冲列表 (由于 新V2 文档错误，暂无法对其完成适配！此功能仍旧处于 V1 ，当更新至 新V2 时，此功能参数可能会更改)
		/// </summary>
		public static async Task<List<PulseList>> GetPulseList()
		{
			string JsonPost = await FTPManager.Get(CoyoteApi.Instance.PulseListApi);
			DeLog(JsonPost);
			return JsonUtility.FromJson<PulseListJson>(JsonPost).pulseList;
		}

		#region 一键开火
		/// <summary>
		/// 一键开火API
		/// </summary>
		/// <param name="strength">一键开火强度，最高40</param>
		/// <param name="time">一键开火时间，单位：毫秒，默认为5000，最高30000（30秒）</param>
		/// <param name="overrides">多次一键开火时，是否重置时间，true为重置时间，false为叠加时间，默认为false</param>
		/// <param name="pulseId">一键开火的波形ID</param>
		public static async void Fire(int strength = 20, int time = 5000, bool overrides = false, string pulseId = "d6f83af0")
		{
			string JsonPost = "strength=" + strength + "&time=" + time + "&override" + overrides + "&pulseId=" + pulseId;
			JsonPost = await FTPManager.Post(CoyoteApi.Instance.FireApi, JsonPost);
			DeLog(JsonPost);
		}
		#endregion

		#region 获取游戏当前波形ID
		/// <summary>
		/// 获取游戏当前波形ID
		/// 注意：与官方文档不同，文档中仅提示 pulseId (列表) 但还存在 currentPulseId (当前)；
		/// 因此，若要获取当前波形ID：请获取 currentPulseId ；若 pulseId 为空，则仅为单一波形
		/// </summary>
		/// <returns></returns>
		public static async Task<PulseId> GetPulseID()
		{
			string JsonPost = await FTPManager.Get(CoyoteApi.Instance.PulseIdApi);
			DeLog(JsonPost);
			return JsonUtility.FromJson<PulseId>(JsonPost);
		}
		#endregion

		#region 设置游戏当前波形ID
		/// <summary>
		/// 设置游戏当前波形ID
		/// </summary>
		/// <param name="pulseId">波形ID</param>
		public static void SetPulseID(string pulseIds)
		{
			string JsonPost = "pulseId=" + pulseIds;

			PulseID(JsonPost);
		}

		/// <summary>
		/// 设置游戏当前波形List
		/// </summary>
		/// <param name="pulseIds">波形List</param>
		public static void SetPulseID(List<string> pulseIds)
		{
			string JsonPost = "";
			foreach (string id in pulseIds)
			{
				JsonPost += "pulseId[]=" + id + "&";
			}

			PulseID(JsonPost);
		}

		private static async void PulseID(string JsonPost)
		{
			JsonPost = await FTPManager.Post(CoyoteApi.Instance.PulseIdApi, JsonPost);
			DeLog(JsonPost);
		}
		#endregion

		#region 游戏强度配置相关
		/// <summary>
		/// 设置基本游戏强度配置
		/// </summary>
		public static class SetStrength
		{
			public static async void Add(int Add = 1)
			{
				string JsonPost = "strength.add=" + Add;
				JsonPost = await FTPManager.Post(CoyoteApi.Instance.StrengthConfigApi, JsonPost);
				DeLog(JsonPost);
			}
			public static async void Sub(int Sub = 1)
			{
				string JsonPost = "strength.sub=" + Sub;
				JsonPost = await FTPManager.Post(CoyoteApi.Instance.StrengthConfigApi, JsonPost);
				DeLog(JsonPost);
			}
			public static async void Set(int Set = 1)
			{
				string JsonPost = "strength.set=" + Set;
				JsonPost = await FTPManager.Post(CoyoteApi.Instance.StrengthConfigApi, JsonPost);
				DeLog(JsonPost);
			}
		}

		/// <summary>
		/// 设置随机游戏强度配置
		/// </summary>
		public static class SetRandomStrength
		{
			public static async void Add(int Add = 1)
			{
				string JsonPost = "randomStrength.add=" + Add;
				JsonPost = await FTPManager.Post(CoyoteApi.Instance.StrengthConfigApi, JsonPost);
				DeLog(JsonPost);
			}
			public static async void Sub(int Sub = 1)
			{
				string JsonPost = "randomStrength.sub=" + Sub;
				JsonPost = await FTPManager.Post(CoyoteApi.Instance.StrengthConfigApi, JsonPost);
				DeLog(JsonPost);
			}
			public static async void Set(int Set = 1)
			{
				string JsonPost = "randomStrength.set=" + Set;
				JsonPost = await FTPManager.Post(CoyoteApi.Instance.StrengthConfigApi, JsonPost);
				DeLog(JsonPost);
			}
		}

		/// <summary>
		/// 获取游戏强度信息
		/// </summary>
		public static async Task<StrengthConfig> GetStrengthConfig()
		{
			string JsonPost = await FTPManager.Get(CoyoteApi.Instance.StrengthConfigApi);
			DeLog(JsonPost);
			return JsonUtility.FromJson<StrengthConfigJson>(JsonPost).strengthConfig;
		}

		#endregion

		private static void DeLog(string JsonPost)
		{
			if(CoyoteApi.DeLogIS)
			{
				Debug.Log("【DGLAB】" + JsonPost);
			}
		}
	}
}