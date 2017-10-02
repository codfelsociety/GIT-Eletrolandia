package com.eletroland.appteem;

import android.content.Intent;
import android.gesture.Gesture;
import android.gesture.GestureLibraries;
import android.gesture.GestureLibrary;
import android.gesture.GestureOverlayView;
import android.gesture.Prediction;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.StringTokenizer;

public class MainActivity extends AppCompatActivity {

    String imagem = "";
    GestureLibrary lib;
    TextView txtStart;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        txtStart = (TextView)findViewById(R.id.txtStart);

        lib = GestureLibraries.fromRawResource(this, R.raw.gestures);
        if(!lib.load()) finish();
        GestureOverlayView gesture = (GestureOverlayView)findViewById(R.id.gesture);
        gesture.addOnGesturePerformedListener(new GestureOverlayView.OnGesturePerformedListener() {
            @Override
            public void onGesturePerformed(GestureOverlayView gestureOverlayView , Gesture gesture) {
                ArrayList<Prediction> predictionArrayList = lib.recognize(gesture);
                for(Prediction prediction : predictionArrayList) {
                    if(prediction.score > 1.0) {
                        txtStart.setText(prediction.name);
                        imagem = prediction.name;
                    }
                }
            }
        });
    }

    public void btnAvancarClick(View v) {
        GoTo(Saturation.class);
    }

    public void GoTo(Class c) {
        Bundle b = new Bundle();
        b.putString("Imagem", imagem);
        Intent intent = new Intent(MainActivity.this, c);
        intent.putExtras(b);
        startActivity(intent);
        finish();
    }
}
