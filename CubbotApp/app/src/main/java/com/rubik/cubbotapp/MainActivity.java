package com.rubik.cubbotapp;

import android.content.ActivityNotFoundException;
import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.view.Menu;
import android.view.MenuItem;
import android.view.Window;
import android.view.WindowManager;
import android.webkit.JavascriptInterface;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.widget.ImageButton;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    WebView webView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        //Remove notification bar
        this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        getSupportActionBar().hide();

        webView = (WebView)findViewById(R.id.webView);
        webView.loadUrl("http://cubbot.azurewebsites.net");
        WebSettings webSettings = webView.getSettings();
        webSettings.setJavaScriptEnabled(true);
        webView.addJavascriptInterface(new WebAppInterface(this), "Android");

        ImageButton fab = (ImageButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "GitHub page", Snackbar.LENGTH_LONG).setAction("Action", null).show();
                try {
                    Intent myIntent = new Intent(Intent.ACTION_VIEW, Uri.parse("https://github.com/orlando26/rubik?files=1"));
                    startActivity(myIntent);
                } catch (ActivityNotFoundException e) {
                    Toast.makeText(getApplicationContext(), "No application can handle this request."
                            + " Please install a webbrowser",  Toast.LENGTH_LONG).show();
                    e.printStackTrace();
                }
            }
        });
    }

    public class WebAppInterface {
        Context mContext;

        /** Instantiate the interface and set the context */
        WebAppInterface(Context c) {
            mContext = c;
        }

        /** Show a toast from the web page */
        @JavascriptInterface
        public void showToast(String toast) {
            Toast.makeText(mContext, toast, Toast.LENGTH_SHORT).show();
        }
    }


}
