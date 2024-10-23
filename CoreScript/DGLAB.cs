namespace lyqbing.DGLAB
{
	using System.Threading.Tasks;
	using UnityEngine;

	public static class DGLAB
	{
		#region 一键开火
		/// <summary>
		/// 一键开火
		/// </summary>
		public static async void Fire(int strength = 1, int time = 1000)
		{
			string JsonPost = "strength=" + strength + "&time" + time;
			JsonPost = await FTPManager.Post(CoyoteApi.Instance.FireApi, JsonPost);
			DeLog(JsonPost);
		}
		#endregion

		#region 脉冲相关
		/// <summary>
		/// 获取脉冲列表
		/// </summary>
		public static async Task<PulseListJson> GetPulseList()
		{
			string JsonPost = await FTPManager.Get(CoyoteApi.Instance.PulseListApi);
			DeLog(JsonPost);
			return JsonUtility.FromJson<PulseListJson>(JsonPost);
		}

		/// <summary>
		/// 获取脉冲ID
		/// </summary>
		public static async Task<PulseId> GetPulseID()
		{
			string JsonPost = await FTPManager.Get(CoyoteApi.Instance.PulseIdApi);
			DeLog(JsonPost);
			return JsonUtility.FromJson<PulseId>(JsonPost);
		}

		/// <summary>
		/// 获取强度配置
		/// </summary>
		public static async Task<StrengthConfigJson> GetStrengthConfig()
		{
			string JsonPost = await FTPManager.Get(CoyoteApi.Instance.StrengthConfigApi);
			DeLog(JsonPost);
			return JsonUtility.FromJson<StrengthConfigJson>(JsonPost);
		}

		/// <summary>
		/// 设置脉冲ID
		/// </summary>
		public static async void SetPulseID(string pulseId)
		{
			string JsonPost = "pulseId=" + pulseId;
			JsonPost = await FTPManager.Post(CoyoteApi.Instance.PulseIdApi, JsonPost);
			DeLog(JsonPost);
		}
		#endregion

		#region 属性相关
		/// <summary>
		/// 设置基本属性
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
		/// 设置随机属性
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

		#endregion

		#region 随机间隔
		/// <summary>
		/// 设置随机间隔
		/// </summary>
		public static class SetInterval
		{
			public static async void Min(int Set)
			{
				string JsonPost = "minInterval.set" + Set;
				JsonPost = await FTPManager.Post(CoyoteApi.Instance.StrengthConfigApi, JsonPost);
				DeLog(JsonPost);
			}
			public static async void Max(int Set)
			{
				string JsonPost = "maxInterval.set" + Set;
				JsonPost = await FTPManager.Post(CoyoteApi.Instance.StrengthConfigApi, JsonPost);
				DeLog(JsonPost);
			}
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