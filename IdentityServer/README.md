# 说明

## Todo

Client

## 依赖

IdentityServer4

## 核心

Client

1. 为每个 Application 应用，分配1个 Client

Token：

- IdentityToken
- AccessToken
- AuthorizationCode
- RefreshToken

Flow：

- ClientCredentials
  - OAuth2
- ResourceOwnerPassword
  - OAuth2
- Implicit
  - 只传输 OpenID 协议
  - Client
    - 配置 OpenID 协议
      - ClientId、SignInScheme、Authority
    - 配置 DefaultChallengeScheme 为 OpenID
  - Server
    - 配置 Client
      - GrantTypes:Implicit、AllowedScopes:openId、RedirectUris:第三方应用 OpenID 地址(Client 端 CallbackPath)
    - 配置 User
      - 配置 subId,userName,password
    - 添加 Identity Resources
      - openid
    - 添加 登录页面
      - `/account/login`  // 可通过 UserInteraction.LoginUrl 配置
      - `await _events.RaiseAsync(new UserLoginSuccessEvent(user.Username, user.SubjectId, user.Username))`
      - `await HttpContext.SignInAsync(user.SubjectId, user.Username, props);`
      - `return Redirect(model.ReturnUrl)`
- Hybrid
  - Implicit + Code 模式
  - 传输 OpenID + OAuth2 协议
  - 在 Implicit 的基础上，添加 client secret(code 转 token需要), ResponseType = "id_token code"(openID 协议只有 id_token)，scope 添加 OAuth2 需要的API

## 示例

## 注意

## 问题

1. `services.AddDeveloperSigningCredential()` 作用及是否能用其他方式?

    设置临时签署凭据：默认使用 tempkey.rsa 作为文件名，判断文件是否存在，不存在则创建 CreateRsaSecurityKey ，通过json序列化保存到文件中。
    在开发环境 或者 单个 IdentityServer 实例的时候，都可以使用 AddDeveloperSigningCredential()
    在多个 IdentityServer 实例的时候，需要使用统一的方式。如：同1个 tempkey.rsa 或者 AddSigningCredential()

1. OpenID协议(客户端|服务端) 默认使用 /connect/xx 如：/connect/token,/connect/userinfo

1. 如何传递 User Cliams

    在 Implicit 模式中，定义 Identity Resource 包含新的 Claim Types。同时在 Client 中，添加对应的 scope
    在 Hybird 模式中，需再配置 AlwaysIncludeUserClaimsInIdToken = true

1. 如何传递 Client Cliams

1. 自定义 Error 页面

1. 如何注销登录

1. `JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();` 根据实际需要，是否禁用映射功能

    开启：在客户端会显示成原始数据
    关闭(默认)：在客户端映射成标准格式的数据