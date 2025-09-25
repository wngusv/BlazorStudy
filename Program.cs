using BlazorStudy.Components;


// 앱 빌더를 만들고 사용할 서비스 준비
// 앱 빌더: 웹앱을 만들기 위한 빌더
// 앱에서 필요한 기능(서비스)들을 모두 추가한 상태에서 앱을 만들면 앱이 너무 무거워지므로 사용할 서비스만 준비를 하는 단계
// blazor = browser + razor
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents() //레이저 컴포넌트 서비스 추가
    // builder에서 razorsyntex를 사용할수 있도록
    .AddInteractiveServerComponents(); //서버 상호작용 컴포넌트 추가, SSR에선 이부분만 없고 나머지 동일



// 앱 만들기
var app = builder.Build();



//앱에 사용할 서비스 추가
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true); // 앱에 예외가 발생했을때 처리하는 미들웨어 추가
    app.UseHsts(); // 앱 보안 설정
}
app.UseHttpsRedirection(); // HTTP 요청을 HTTPS 요청으로 리다이렉트
app.UseAntiforgery(); // CSRF 공격 방지 미들웨어 추가
app.MapStaticAssets(); // 정적 자산(이미지, CSS, JS 등) 제공 미들웨어 추가, wwwroot 폴더 사용 가능
app.MapRazorComponents<App>() // Component 폴더 사용 가능, App.razor에서 시작됨
    .AddInteractiveServerRenderMode(); // Razor 컴포넌트를 서버 상호작용 모드로 매핑


// 앱 실행
app.Run();
