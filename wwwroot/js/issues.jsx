class IssuesList extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            issuesList: []
        };
    }

    loadData = () => {
        var xhr = new XMLHttpRequest();
        xhr.open("get", this.props.apiPath + 'GetIssues', true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ issuesList: data });
        }.bind(this);
        xhr.send();
    }

    componentDidMount() {
        this.loadData();
    }
    
    deleteIssue = (id) => {
        var xhr = new XMLHttpRequest();
        xhr.open("post", this.props.apiPath + 'DeleteIssue?id=' + id, true);
        xhr.onload = function () {
            if (xhr.status === 200) {
                //вариант с обновлением списка целиком
                //var data = JSON.parse(xhr.responseText).value;
                //this.setState({ issuesList: data });

                //вариант с удалением единственного элемента в состоянии
                var newIssueList = this.state.issuesList.filter((x) => { return x.id != id });
                this.setState({ issuesList: newIssueList });
            }
            else alert("Ошибка при удалении");
        }.bind(this);
        xhr.send();
    }

    render() {
        var deleteIssueFunc = this.deleteIssue;
        var issues = this.state.issuesList;
        return (
            <div className="container-fluid">
                {
                    issues.map(function (x) {
                        return <Issue id={x.id} issueText={x.issueText} issueName={x.issueName}
                            isComplited={x.isComplited} userId={x.userId} deleteIssue={deleteIssueFunc} key={x.id} />
                    })
                }
            </div>
            );
    }
}

class Issue extends React.Component {
    constructor(props) {
        super(props);
        var paramArr = [props.id, props.issueText, props.issueName, props.isComplited, props.userId];
        this.state = {
            id: paramArr[0],
            issueText: paramArr[1],
            issueName: paramArr[2],
            isComplited: paramArr[3],
            userId: paramArr[4]
        };
    }

    render() {
        return (
            <div className="col-6 mx-auto container issue">
                <h1 className="row col display-4 mx-auto">{this.state.issueName}</h1>
                <p className="row text-justify">{this.state.issueText}</p>
                <div className="row checkboxDiv">
                    <input className="" type="checkbox" checked={this.state.isComplited} disabled="disabled"></input>
                    <label className="form-check-label my-auto">Выполнено</label>
                </div>
                <div className="row">
                    <button className="btn btn-outline-warning col" data-toggle="modal" data-target={"#issue" + this.state.id}>Изменить</button>
                    <button className="btn btn-outline-danger col" onClick={() => { this.props.deleteIssue(this.state.id) }}>Удалить</button>
                </div>
                <EditOrCreateIssue isNew={false} id={this.state.id} issueText={this.state.issueText} issueName={this.state.issueName} isComplited={this.state.isComplited} />
            </div>
            );
    }
}


class EditOrCreateIssue extends React.Component {
    //до create допили
    constructor(props) {
        super(props);
    }


    render() {
        return (
            <div className="modal fade issueModal" id={!this.props.isNew ? "issue" + this.props.id : "dasdasda"} data-backdrop="static"
                data-keyboard="false" tabIndex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title" id="staticBackdropLabel">{this.props.isNew == true ? "Создание задачи" : "Редактирование задачи"}</h5>
                            <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div className="container-fluid">
                            <input type="text" className="row mx-auto form-control" placeholder="Название задачи" value={!this.props.isNew ? this.props.issueName : "dasdasda"} onChange={e => this.value = e.value} />
                            <textarea className="row mx-auto form-control" id="message-text" placeholder="Описание задачи"></textarea>
                            <div className="row">
                                <input type="checkbox" className="col-1" />
                                <label className="col-5 form-check-label my-auto">Выполнено</label>
                            </div>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-secondary" data-dismiss="modal">Закрыть</button>
                            <button type="button" className="btn btn-primary">Сохранить</button>
                            </div>
                    </div>
                </div>
            </div>
        );
    }

}


class Content extends React.Component {

    logout() {
        var xhr = new XMLHttpRequest();
        xhr.open("get", '/auth/logout', true);
        xhr.onload = function () {
            if (xhr.status === 200) {
                window.location = '/';
            }
        }.bind(this);
        xhr.send();
    }

    render() {
        var apiPath = "/issues/"
        return (
            <div>
                <h1 className="mx-auto">Список задач</h1>
                <button onClick={this.logout}>Выйти</button>
                <IssuesList apiPath={apiPath} />
            </div>
            );
    }
}


ReactDOM.render(
    <Content />,
    document.getElementById("content")
);