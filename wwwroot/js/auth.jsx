class Login extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            login: '',
            pass: '',
            registr: false,
            role: 1
        };
    }

    onClick = () => {
        var xhr = new XMLHttpRequest();
        if (!this.state.registr)
            xhr.open("get", this.props.apiPath + 'login/' + '?userName=' + this.state.login + '&pass=' + this.state.pass, true);
        else
            xhr.open("post", this.props.apiPath + 'registr/' + '?userName=' + this.state.login + '&pass=' + this.state.pass +
                '&role=' + this.state.role, true);
        xhr.onload = function () {
            if (xhr.status === 200) {
                window.location = '/issues';
            }
        }.bind(this);
        xhr.send();
    }

    onLoginChanged = (e) => {
        this.setState({ login: e.target.value });
    }

    onPassChanged = (e) => {
        this.setState({ pass: e.target.value });
    }

    onRegistrClick = () => {
        this.setState({ registr: !this.state.registr });
    }

    onSelectChange = (e) => {
        this.setState({ select: e.target.value });
    }

    onRoleChanged = (e) => {
        this.setState({ role: e.target.value });
    }



    render() {
        var role = null;
        if (this.state.registr == true)
            role = (
                <select class="row mx-auto col-3 login_pass_input" onChange={this.onRoleChanged}>
                    <option value='1'>Пользователь</option>
                    <option value='2'>Администратор</option>
                </select>
                );
        return (
            <div class="container-fluid">
                <div class="col center">
                    <input class="row col-6 mx-auto" type="text" onChange={this.onLoginChanged} placeholder="login" />
                    <input class="row col-6 mx-auto" type="password" onChange={this.onPassChanged} placeholder="password"/>
                {role}
                    <div class="row col-6 mx-auto">
                        <button onClick={this.onClick} class="btn col btn-primary">
                        {this.state.registr == true ? 'Зарегистрироваться' : 'Войти'}
                    </button>
                        <button onClick={this.onRegistrClick} class="btn col btn-primary">
                        {this.state.registr == true ? 'У меня есть аккаунт' : 'Зарегистрироваться'}
                    </button>
                </div>
                </div>
            </div>
            );
    }
}


ReactDOM.render(
    <Login apiPath="/Auth/" />,
    document.getElementById("content")
);
