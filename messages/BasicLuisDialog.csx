using System;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

// For more information about this template visit http://aka.ms/azurebots-csharp-luis
[Serializable]
public class BasicLuisDialog : LuisDialog<object>
{
    public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(Utils.GetAppSetting("LuisAppId"), Utils.GetAppSetting("LuisAPIKey"))))
    {
    }
    
    [LuisIntent("None")]
    public async Task NoneIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You have reached the none intent. You said: {result.Intents}"); //
        context.Wait(MessageReceived);
    }


    // Go to https://luis.ai and create a new intent, then train/publish your luis app.
    // Finally replace "MyIntent" with the name of your newly created intent in the following handler
    [LuisIntent("StockPrice")]
    public async Task StockPrice(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You have reached the StockPrice intent. You meant: {YahooStock.GetStockRateAsync(result.Entities[0].Entity)}"); //
        context.Wait(MessageReceived);
    }


    [LuisIntent("StockPrice2")]
    public async Task StockPrice2(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You have reached the StockPrice2 intent. You meant: {YahooStock.GetStockRateAsync(result.Entities[0].Entity)}"); //
        //await context.PostAsync($"You have reached the StockPrice2 intent. You meant: {result.Entities[0].Entity}"); //
        context.Wait(MessageReceived);
    }
}