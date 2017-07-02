package br.com.itb.teem.eletrolandia2;


import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

public class Tela5AvalieApp extends Activity implements OnClickListener {
	Button btnVoltarTelaAvalie, RatingBarAvalie;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.tela5avalieapp);

		btnVoltarTelaAvalie = (Button) findViewById(R.id.btnVoltarTA);
		btnVoltarTelaAvalie.setOnClickListener(this);
	}

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.btnVoltarTA:
			Intent t1 = new Intent(this, Tela1Inicial.class);
			startActivity(t1);
			break;
		}

	}
}
