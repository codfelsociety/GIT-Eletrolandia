package com.eletroland.appeletrolandia;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;

public class TelaInicialActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_tela_inicial);
    }

    public void btnSeekBar_Click(View v) {
        GoTo(SeekBarActivity.class);
    }

    public void btnImageSwitcherClick(View v) {
        GoTo(ImageSwitcherActivity.class);
    }

    public void btnSurfaceView_Click(View v) {
        GoTo(SurfaceViewActivity.class);
    }

    public void GoTo(Class c) {
        startActivity(new Intent(TelaInicialActivity.this,c));
    }
}
