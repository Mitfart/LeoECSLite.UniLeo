# UniLeo - Интеграция в редактор Unity для LeoECS Lite
Интеграция в редактор Unity для конвертации Unity в ECS

Интеграция вдохновлена [UniLeo-Lite от Voody](https://github.com/Mitfart/UniLeo-Lite)



# Содержание
* [Социальные ресурсы](#Социальные-ресурсы)
* [Установка](#Установка)
    * [В виде unity модуля](#В-виде-unity-модуля)
    * [В виде исходников](#В-виде-исходников)
* [Интеграция](#Интеграция)
    * [В коде](#В-коде)
    * [В редакторе](#В-редакторе)
* [Почему?](#Почему?)
* [Оптимизация](#Оптимизация)
* [ЧаВо](#ЧаВо)

# Социальные ресурсы
> #### Discord [Группа по LeoEcsLite](https://discord.gg/5GZVde6)
> #### Telegram [Группа по Ecs](https://t.me/ecschat)



# Установка

> **ВАЖНО!** Зависит от [LeoECS Lite](https://github.com/Leopotam/ecslite) - фреймворк должен быть установлен до этого расширения.

## В виде unity модуля
Поддерживается установка в виде unity-модуля через git-ссылку в PackageManager или прямое редактирование `Packages/manifest.json`:
```
"com.mitfart.leoecslite.unileo": "https://github.com/Mitfart/LeoECSLite.UniLeo.git",
```

## В виде исходников
Код так же может быть склонирован или получен в виде архива со страницы релизов.


# Интеграция

## В коде
### Подключение системы
```c#
 _systems = new EcsSystems(world);
 _systems
    ...
    .Add(new ConvertSceneSys())
    .Init();
```
> **ВАЖНО** Обратите внимание что система подключается **САМОЙ** последней

### Объявление компенента
> Для отображения компонента в редакторе, необходимо создать **Провайдер**  
> `(Провайдер - MonoBehaviour, наследующий IConvertToEntity)`

Самы простой способ это:
```c#
public sealed class CompProvider : EcsProvider<Comp>{ }

[Serializable] // <-- Обязательный аттрибут, для отображения в инспекторе
public struct Comp {
    public string value;
}
```
Также можно создавать свои "Провайдеры":
```cs
// -- 1 СПОСОБ -- //
// Override стандартный
public sealed class CompProvider_V1 : EcsProvider<Comp>{
  public override void Convert(int e, EcsWorld world){
    component = new Comp();
    base.Convert(e, world);
  }
}


// -- 2 СПОСОБ -- //
// Унаследовать BaseEcsProvider или IConvertToEntity
public sealed class CompProvider_V2 : BaseEcsProvider {
  public override void Convert(int e, EcsWorld world){
    ...
  }
}

```
