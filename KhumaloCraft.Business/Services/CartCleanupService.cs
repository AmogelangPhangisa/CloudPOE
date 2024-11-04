using KhumaloCraft.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KhumaloCraft.Business.Services;

public class CartCleanupService : BackgroundService
{
  private readonly IServiceScopeFactory _scopeFactory;

  public CartCleanupService(IServiceScopeFactory scopeFactory)
  {
    _scopeFactory = scopeFactory;
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      await CleanupOldCartsAsync();
      await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
    }
  }

  private async Task CleanupOldCartsAsync()
  {
    using var scope = _scopeFactory.CreateScope();
    var cartRepository = scope.ServiceProvider.GetRequiredService<ICartRepository>();

    var expirationDate = DateTime.UtcNow.AddDays(-30);
    var oldCarts = cartRepository.GetCartsOlderThan(expirationDate);

    foreach (var cart in oldCarts)
    {
      cartRepository.DeleteCart(cart.CartId);
    }

    await Task.CompletedTask;
  }
}

