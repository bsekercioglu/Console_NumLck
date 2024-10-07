
# NumLock Kontrol Uygulaması (C#)

Bu C# konsol uygulaması, NumLock tuşunun durumunu kontrol eder ve NumLock etkin değilse programatik olarak etkinleştirir. Bu işlem, Windows API fonksiyonları olan `GetKeyState` ve `keybd_event` kullanılarak gerçekleştirilir.

## Özellikler

- **NumLock durumunu kontrol etme:** Uygulama, NumLock tuşunun şu an aktif olup olmadığını kontrol eder.
- **NumLock'u aktif hale getirme:** Eğer NumLock aktif değilse, program NumLock tuşuna basılmasını simüle ederek aktif hale getirir.
- **Platform Desteği:** Yalnızca Windows işletim sistemi üzerinde çalışır.

## Gereksinimler

- **Windows İşletim Sistemi**
- **.NET Framework** veya **.NET Core**

Bu uygulama, Windows'a özgü olan aşağıdaki API çağrılarını kullanır:
- `keybd_event`
- `GetKeyState`

## Nasıl Çalışır

1. **NumLock Durumunu Kontrol Etme:**  
   Program, `user32.dll` kütüphanesinden `GetKeyState` fonksiyonunu kullanarak NumLock tuşunun şu an açık olup olmadığını kontrol eder. Eğer NumLock açık değilse, program tuşun aktif hale getirilmesi için gerekli işlemi yapar.
   
2. **NumLock'u Aktif Etme (Kapalıysa):**  
   NumLock kapalıysa, program `keybd_event` fonksiyonunu kullanarak NumLock tuşuna basıp bırakmayı simüle eder ve tuşu aktif hale getirir.

## Kurulum

1. Projeyi yerel makinenize klonlayın:
   ```bash
   git clone https://github.com/kullanici-adiniz/numlock-kontrol.git
   ```

2. Projeyi Visual Studio veya tercih ettiğiniz bir C# IDE'sinde açın.

3. Çözümü (solution) derleyin ve çalıştırın.

## Kullanım

Uygulamayı çalıştırdığınızda, mevcut NumLock durumu kontrol edilir ve eğer NumLock kapalıysa, aktif hale getirilir. Eğer NumLock zaten aktifse, program hiçbir işlem yapmadan durumu bildirir.

### Örnek Çıktılar

- Eğer NumLock **kapalıysa**:
   ```
   NumLock aktif hale getirildi.
   ```

- Eğer NumLock **zaten aktifse**:
   ```
   NumLock zaten aktif.
   ```

## Kodun Genel Yapısı

### Ana Fonksiyonlar

1. **GetKeyState Fonksiyonu:**
   ```csharp
   [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
   public static extern short GetKeyState(int keyCode);
   ```
   Bu fonksiyon, NumLock tuşunun mevcut durumunu kontrol eder.

2. **keybd_event Fonksiyonu:**
   ```csharp
   [DllImport("user32.dll", SetLastError = true)]
   public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
   ```
   Bu fonksiyon, NumLock tuşuna basma ve bırakma olayını simüle eder.

### NumLock Durumunu Kontrol Etme

`IsNumLockOn` metodu, NumLock tuşunun aktif olup olmadığını belirler:

```csharp
static bool IsNumLockOn()
{
    return (GetKeyState(VK_NUMLOCK) & 0x0001) != 0;
}
```

### NumLock Tuşuna Basmayı Simüle Etme

`PressNumLockKey` metodu, NumLock tuşuna basma ve bırakmayı simüle eder:

```csharp
static void PressNumLockKey()
{
    keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY, UIntPtr.Zero);
    keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, UIntPtr.Zero);
}
```

## Katkıda Bulunma

Katkıda bulunmak isterseniz, fork alıp bir pull request oluşturabilirsiniz!

1. Depoyu fork'layın.
2. Yeni bir özellik dalı oluşturun (`git checkout -b feature/AmazingFeature`).
3. Değişikliklerinizi commit'leyin (`git commit -m 'Harika bir özellik ekledim'`).
4. Dalı depoya push edin (`git push origin feature/AmazingFeature`).
5. Bir pull request açın.

## Lisans

Bu proje MIT Lisansı ile lisanslanmıştır - ayrıntılar için [LICENSE](LICENSE) dosyasına bakabilirsiniz.

## Teşekkürler

- [Microsoft Docs](https://docs.microsoft.com) - Windows API fonksiyonları hakkında detaylı dokümantasyon için.
