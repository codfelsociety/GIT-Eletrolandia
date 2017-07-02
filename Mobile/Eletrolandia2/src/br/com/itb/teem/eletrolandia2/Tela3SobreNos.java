package br.com.itb.teem.eletrolandia2;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

public class Tela3SobreNos extends Activity implements OnClickListener {
	Button btnVoltar;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.tela3_sobre_nos);

		btnVoltar = (Button) findViewById(R.id.btnVoltarTelaSN);
		btnVoltar.setOnClickListener(this);
	}

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.btnVoltarTelaSN:
			Intent t1 = new Intent(this, Tela1Inicial.class);
			startActivity(t1);
			break;
		}

	}

}
