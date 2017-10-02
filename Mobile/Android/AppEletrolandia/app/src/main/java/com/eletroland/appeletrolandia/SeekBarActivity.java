package com.eletroland.appeletrolandia;

import android.content.Intent;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;

public class SeekBarActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_seek_bar);
    }

    public void btnVoltar_Click(View v) {
        GoTo(TelaInicialActivity.class);
    }

    public void btnShow_Click(View v) {

    }

    private void GoTo(Class c) {
        Intent page = new Intent(SeekBarActivity.this, c);
        startActivity(page);
    }
}
