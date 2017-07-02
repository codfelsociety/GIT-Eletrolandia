package br.com.itb.teem.eletrolandia2;
import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

public class Tela4FaleConosco extends Activity implements OnClickListener {
	Button btnVoltarFC, btnEnviarTelaFC;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.tela4faleconosco);
		btnVoltarFC = (Button) findViewById(R.id.btnVoltarFC);
		btnVoltarFC.setOnClickListener(this);
		
		btnEnviarTelaFC = (Button) findViewById (R.id.btnEnviarTelaFC);
		btnEnviarTelaFC.setOnClickListener(this);
	}
	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.btnVoltarFC:
			Intent t1 = new Intent(this, Tela1Inicial.class);
			startActivity(t1);
			break;	
		/*case R.id.btnEnviarTelaFC:
			Intent t2 = new Intent(this,Tela1_Inicial.class);
			startActivity(t2);
			break;*/
		}
		
	}
}
