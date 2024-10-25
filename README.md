# DG-Lab-for-Unity
让你的 Unity 游戏 或 基于 C# 的项目开发 连接到 DG-Lab，由 <a href="https://github.com/hyperzlib/DG-Lab-Coyote-Game-Hub">DG-Lab-Coyote-Game-Hub</a> 的 API 实现。

# 对于 Unity 项目
你可以导入直接使用，且可以直接获取对应API的回执信息。

举例：data.strengthConfig.strength ...
（根据官方API文档的Json回执命名，因此可以直接参考官方文档）

注：默认采用内置UnityJson实现，若想使用高级操作，请使用第三方Josn库自行实现

# 对于 C# 项目
内置的 UnityJson 操作您将无法使用，请手动移除所有 Unity 相关代码（这并不多）

如果您只需要对 DG 设备发送惩罚操作则可无视以下内容：

因没有 UnityJson 的支持，所有回执您只能获得 Json 文本，您无法直接获取对应 API 的回执信息
您可以通过第三方 Json 库，请自行实现 Json 获取。

# 没有 Json 解析会错过什么？
获取游戏相应数据时，数据将会以Json 回执。
如果你只需要在触发对应操作时降下惩罚，则您完全不需要Json。

举例：
获取玩家当前脉冲
获取玩家当前输出值
等...
