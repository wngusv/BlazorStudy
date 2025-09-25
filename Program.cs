using BlazorStudy.Components;


// �� ������ ����� ����� ���� �غ�
// �� ����: ������ ����� ���� ����
// �ۿ��� �ʿ��� ���(����)���� ��� �߰��� ���¿��� ���� ����� ���� �ʹ� ���ſ����Ƿ� ����� ���񽺸� �غ� �ϴ� �ܰ�
// blazor = browser + razor
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents() //������ ������Ʈ ���� �߰�
    // builder���� razorsyntex�� ����Ҽ� �ֵ���
    .AddInteractiveServerComponents(); //���� ��ȣ�ۿ� ������Ʈ �߰�, SSR���� �̺κи� ���� ������ ����



// �� �����
var app = builder.Build();



//�ۿ� ����� ���� �߰�
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true); // �ۿ� ���ܰ� �߻������� ó���ϴ� �̵���� �߰�
    app.UseHsts(); // �� ���� ����
}
app.UseHttpsRedirection(); // HTTP ��û�� HTTPS ��û���� �����̷�Ʈ
app.UseAntiforgery(); // CSRF ���� ���� �̵���� �߰�
app.MapStaticAssets(); // ���� �ڻ�(�̹���, CSS, JS ��) ���� �̵���� �߰�, wwwroot ���� ��� ����
app.MapRazorComponents<App>() // Component ���� ��� ����, App.razor���� ���۵�
    .AddInteractiveServerRenderMode(); // Razor ������Ʈ�� ���� ��ȣ�ۿ� ���� ����


// �� ����
app.Run();
