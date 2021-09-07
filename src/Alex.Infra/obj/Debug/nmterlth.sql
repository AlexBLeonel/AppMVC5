CREATE TABLE [dbo].[Enderecos] (
    [Id] [uniqueidentifier] NOT NULL,
    [Logradouro] [nvarchar](200) NOT NULL,
    [Numero] [nvarchar](10) NOT NULL,
    [Complemento] [nvarchar](200),
    [CEP] [nchar](8) NOT NULL,
    [Bairro] [nvarchar](100) NOT NULL,
    [Cidade] [nvarchar](150) NOT NULL,
    [Estado] [nvarchar](80) NOT NULL,
    CONSTRAINT [PK_dbo.Enderecos] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Fornecedores] (
    [Id] [uniqueidentifier] NOT NULL,
    [Nome] [nvarchar](200) NOT NULL,
    [Documento] [nvarchar](14) NOT NULL,
    [Tipo] [int] NOT NULL,
    [Status] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.Fornecedores] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Produtos] (
    [Id] [uniqueidentifier] NOT NULL,
    [FornecedorId] [uniqueidentifier] NOT NULL,
    [Nome] [nvarchar](100) NOT NULL,
    [Descricao] [nvarchar](1000) NOT NULL,
    [Imagem] [nvarchar](100) NOT NULL,
    [Valor] [decimal](18, 2) NOT NULL,
    [DataCadastro] [datetime] NOT NULL,
    [Status] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.Produtos] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_Id] ON [dbo].[Enderecos]([Id])
CREATE INDEX [IX_FornecedorId] ON [dbo].[Produtos]([FornecedorId])
ALTER TABLE [dbo].[Enderecos] ADD CONSTRAINT [FK_dbo.Enderecos_dbo.Fornecedores_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[Fornecedores] ([Id])
ALTER TABLE [dbo].[Produtos] ADD CONSTRAINT [FK_dbo.Produtos_dbo.Fornecedores_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [dbo].[Fornecedores] ([Id]) ON DELETE CASCADE
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'202109072221095_AutomaticMigration', N'Alex.Infra.Migrations.Configuration',  0x1F8B0800000000000400E55B5F6FDB36107F1FB0EF20E8714BAD385D812CB05B247652786BFE20768ABD05B474768849942A52818D629F6C0FFB48FB0A3B59FF48FDB72D67298ABEC427F277BCE3DDF178C7FEFBF73F830F2BC7D69EC1E7D46543BDDF3BD63560A66B51B61CEA8158BC39D53FBCFFF187C1A5E5ACB4CFC9B8B7E1389CC9F8507F12C23B330C6E3E814378CFA1A6EF7277217AA6EB18C4728D93E3E35F8D7EDF0084D0114BD306F70113D481CD0FFC397299099E08887DED5A60F3988E5FA61B54ED8638C03D62C2503FB761D59BB0854F7A6322480FE70A58095D3BB729C1E54CC15EE81A61CC1544E062CF1E384C85EFB2E5D44302B1676B0F70DC82D81C6221CEB2E16DE5393E09E531B28909941970E13A5B02F6DFC60A32F2D37752B39E2A10557889AA16EB50EA8D1A87FA25B3C007D3D5B53CB3B391ED8703632D5F049C32E0BC17ED4AEFCAF5199860B93EF05E8272A429638F5223415B0AFF1D69A3C016810F430681F0897DA4DD05739B9ABFC37AE6FE096CC802DB96578C6BC66F0A014977BEEB812FD6F7B088E59858BA66A8F38CFCC4749A342792F06340F1EF1BE44DE636A4F660D44EFFE42E7DD475E0BB090C9A16BA8AAE5D93D527604BF134D4712374ED8AAEC04A2831F603A3E8593849F8016CCDFB2670A0966FFF206C47AEE3D9E000135DC8DCC0EBF2AE86C7698E4384B89F741784FA0D4A3D8C56A9452CA8E3FBEE207C2FB940FBAD5372376C6FC8335D6E624A6E01590CD1B57BB03743F813F5A2C02D8598C72C4C5DF9AE73EFDACAECF4F3E38CF84BC0F83F73ABC74CD165CDDC2A074616196BE3A5BCE47D2266F6E3BB8A9937AE5367E8078A9663D70C9A8256FF9743709E512F631ADA7448906D684BBC295A5AC013C40B178D9CB03D3C30F3AB6EFC2FF1AD3AFF4B7CB4ED1AF1A715089797AE31FEF828EB345B62F16B2142940CD92B40C4785B478744CAE48FEF2A2C64CA3F6C7C39D0013E066EFAD4240DB9C341784F1CB204E7E565FE4CECD0D722B66330A9436C5DBB430FA7F1F51153B4A94942C093ED358AB7B911B1081759428634985167FBA5761D341BD296AD43523E68D644AD76212970A480943F7126FCCA26CBECD2DB4D16F3B3CAA6A3E885368A8786BD469B8E963461E2ED492EA85D8333073F09BFC8CD2557688326D13534D20089FDC2DE96CCF92DF0A925CF3A29AA3B52AC4C3CC7A926DD28AE601DD9A9A93247B2D6E208CD920679FBAE516FD4434DE1CE9749560F9E9E7E197876B43741E311812359583719A1C5E3B651268AE7096526F588DD2C626E6ACBC328DC899449FECB183C402E4C34EB6077EE2993DC21D9A49F8121594BBD1195C490AA6DAE0B28D92EA76989BAC93FD5D84F5DF2D4CE36F39ABB6563B04180766E46D5B011E1E6E6EA9BCF3770151DD85EB5042F607AD5FBD286B99A11BD800D4667495840C51969683CF7BCF1455A552D1C150F1CE2D382C76944DE9842D02988DC75030FE3ECEC2AC4A18245AA20F2095482231B64035276B328A0A4FE928390B457B622E9A2248DACB94FE537B6DDD9900A92D746C150DA1D07129EB44579A754656FA197B24CA8A896A658D736DA4942641B5BA3909AF8D652BF352A4992B3D4A1B2368611F531927E8751D1F0185C13CFC3C4476A80C4146D1A753F466FA6DB77049C08C330794963205D6DCA49B83EDE2F725FC342B00557D4E7224CD4E724CC2347965318A6848F0A5F4C58E5234471E312174D66847FC761AABC0FD4AB72B34C9757285E581ADA480A257E509CBAE944119BF82577E0916B070EAB3E3FAA67CBDD041945A6B7474BFA033252426B8FA294FB6528E5C3167861495FC10909EDE727057A1922A16DB18AB8DCAE2C24A6B547498AE7324A422BA20C8C9CBD150EF48279173222D55F5A799312BCBA70A8EA18DDC2A5EA261FC6A9A27290E2041B4A7B04A9742CC348E4F658513158868928ED11924A868C91D05E8DD1A5876F170697E461DB5B5BE5CCC3989A9AB0CB38F5A97C356207C69BD52515E3CDC8EDB1923AA3A2A198D61E25AE1ACA2031690BA994DAA02298F2E59B74AB42DE981F92724FF3C75C9E388873B6E6D73385242E1A125671DD676A8509DC74CD0538914B4EBFD8239BA2BCD9806BC2E802B8884A76FAC971FF24F7F6E6F5BC833138B7EC9D1FC34CF0D36AA87FD5FE7AF9964AC0E897006878DBA70B0A659DE77479E1DC336DF2C7E3C43AD26E7D94E74C3BC645EFFFB8853D13DF7C227EB161BBD7DB9552D8FEF6A8254F53DAAC78CB9728AC8077BAE733930AF9775080F28AA41CF6DDF6B0EA239152D8D326D46E5E57BC2E17DCA331D9992715DE3564C8E5DA7B4C6784AD14249C6703B4AFDA843F6CE43CD366E81661D4C83D90D8E3F5030DCF8DBD1A7773DA84D04193FE9B36B2B236FA4E87870CB4D731D268F6BB44BA42BBBD0A797B68B59BDED98A9566B9F512CD728B0810FB37CB77F7B9AE1AA31D3442B3B4AE45DBF3B8D7EBBCF3F912EDA69A52E7B7D9D7DCC1043AEC3716DA04BB7553BF01C3A9AEB0BCDAAE64B1FBD0AEED58DB758C2EBF1839E7E15E47F1AEBA1956DD946C684996B1A9ED3155342DEB7A96653CAA5A62FF4B47B3A2C356DBAECB6FA2DAA57995CDCAFD04CE6DB452D43C4823B2583842CF95FE7316860E4E971944F85FB55010C567D33113B6709300925B51322497795C03DE34D1A1CF7DCC548929F0B3099C6FDE33C64FB22E9D395813761B082F10283238737B2D2B230C4175FC37DD5675CD835B6FF380AF0B11709934CCBC6ED945406D2B5DF75549DE540111C6B68F80F4682F31540A58AE53A41B97B5048AD59786E419389E8D60FC964DC933ECB2B6070E9F6049CC7552FFAB0669DE0855ED8331254B9F383CC6C8E6E34FB461CB59BDFF0F2B3FDF8DA3380000 , N'6.4.4')

