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
- Hybrid
  - 传输 OpenID + OAuth2 协议
  - 在 Implicit 的基础上，添加 client secret(code 转 token需要), ResponseType = "id_token code"(openID 协议只有 id_token)，scope 选择指定的API

## 示例

## 注意

## 问题

1. `services.AddDeveloperSigningCredential()` 作用及是否能用其他方式?

    设置临时签署凭据：默认使用 tempkey.rsa 作为文件名，判断文件是否存在，不存在则创建 CreateRsaSecurityKey ，通过json序列化保存到文件中。
    在开发环境 或者 单个 IdentityServer 实例的时候，都可以使用 AddDeveloperSigningCredential()
    在多个 IdentityServer 实例的时候，需要使用统一的方式。如：同1个 tempkey.rsa 或者 AddSigningCredential()