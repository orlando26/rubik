package com.rubik.cubbotapp;

import android.content.ActivityNotFoundException;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ActivityInfo;
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

import com.orlando.arduino.Arduino;

public class MainActivity extends AppCompatActivity {

    WebView webView;
    Arduino arduino;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE);
        //Remove notification bar
        this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        getSupportActionBar().hide();

        arduino = new Arduino(this);

        webView = (WebView)findViewById(R.id.webView);
        webView.loadUrl("http://cubbot.azurewebsites.net");
        WebSettings webSettings = webView.getSettings();
        webSettings.setJavaScriptEnabled(true);
        webView.addJavascriptInterface(new WebAppInterface(this), "Android");
    }

    public class WebAppInterface {
        Context mContext;

        /** Instantiate the interface and set the context */
        WebAppInterface(Context c) {
            mContext = c;
        }

        /** Show a toast from the web page */
        @JavascriptInterface
        public void sendToArduino(String algs) {
            arduino.write(algs);
        }

        @JavascriptInterface
        public void connectArduino() {
            arduino.connect();
            Toast.makeText(mContext, "Se conecto arduino", Toast.LENGTH_SHORT).show();
        }

        @JavascriptInterface
        public void disconnectArduino() {
            arduino.disconnect();
            Toast.makeText(mContext, "Se desconecto arduino", Toast.LENGTH_SHORT).show();
        }

        @JavascriptInterface
        public void moveCancelled(String move) {
            Toast.makeText(mContext, "Se cancelo " + move, Toast.LENGTH_SHORT).show();
        }
    }


}
